    using System;
    using Gtk;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using System.Xml;
    using System.Collections.Generic;
    using System.Collections;
    using System.Data.Linq;
    using System.Linq;
    
    namespace TestWinForms
    {
    	/// <summary>
    	/// New cell renterer text. derived from Gtk.CellRendererText
    	/// this was neccessary to host the column Index and a Name
    	/// ( in this sample  the Attribute name, you can also define 
    	///   an oibject a dataRow or a XElement ... to use it directly.)
    	/// </summary>
    	public class NewCellRentererText : CellRendererText
    	{
    		public int ColumnIndex{ get; set;}
    		public string XmlAttributeName{ get; set;}
    	}
    	/// <summary>
    	/// Main class.
    	/// </summary>
    	public class MainClass
    	{
    		/// <summary>Loaded XElement to show, edit and store </summary>
    		private XElement MainXMLElement ;
    		/// <summary>TreeStore used in several methodes</summary>
    		private Gtk.TreeStore musicListStore;
    		/// <summary>
    		/// The editing queue.to find the correct Row that have been edited this is neccessary
    		/// because the c# Integration of Gtk2 seems to be not thread safe
    		/// </summary>
    		private Queue<object> EditingQueue = new Queue<object>();
    
    		/// <summary>
    		/// The X element indexer.
    		/// host for all editable XElements in the Tree
    		/// using UserData results in an horrible Mix from managed and unmanaged code
    		/// this way is clean safe.
    		/// 
    		/// An other solution will be to store the datareferences in an additional
    		/// Property of NewCellRentererText 
    		/// 
    		/// </summary>
    		public Dictionary<TreeIter,XElement> XElementIndexer = new Dictionary<TreeIter, XElement> ();
    
    		/// <summary>
    		/// Gets or sets the dynamic tree filter reg ex.
    		/// for filtering , this was only experimental, but it works fine. 
    		/// So if it is needed ....
    		/// </summary>
    		/// <value>The dynamic tree filter reg ex.</value>
    		public System.Text.RegularExpressions.Regex DynamicTreeFilterRegEx { get; set;} 
    		/// <summary>
    		/// Gets or sets the dynamic tree filter column.
    		/// for filtering , this was only experimental, but it works fine. 
    		/// So if it is needed ....
    		/// </summary>
    		/// <value>The dynamic tree filter column.</value>
    		public Int32 DynamicTreeFilterColumn { get; set; }
    
    		/// <summary>
    		/// The entry point of the program, where the program control starts and ends.
    		/// </summary>
    		/// <param name="args">The command-line arguments.</param>
    		public static void Main (string[] args)
    		{
    			Gtk.Application.Init ();
    			new MainClass ();
    			Gtk.Application.Run ();
    
    		}
    		/// <summary>
    		/// Handles the window destroyed_callback event.
    		/// safe my work :-)
    		/// </summary>
    		/// <param name="o">O.</param>
    		/// <param name="args">Arguments.</param>
    		public void On_WindowDestroyed_callback(object o, EventArgs args)
    		{
    			MainXMLElement.Save(System.IO.Path.Combine("Properties","ProcessOut.xml"));
    		}
    		/// <summary>
    		/// Handles the editing canceled_callback event.
    		/// </summary>
    		/// <param name="o">O.</param>
    		/// <param name="args">Arguments.</param>
    		public void On_EditingCanceled_callback(object o, EventArgs args)
    		{
    			EditingQueue.Dequeue();
    		}
    
    		/// <summary>
    		/// Handles the editing started_callback event.
    		/// </summary>
    		/// <param name="o">O.</param>
    		/// <param name="args">Arguments.</param>
    		public void On_EditingStarted_callback(object o, EditingStartedArgs args)
    		{
    			EditingQueue.Enqueue (o);
    		}
    
    		/// <summary>
    		/// Handles the edited_callback event.
    		/// </summary>
    		/// <param name="o">O.</param>
    		/// <param name="args">Arguments.</param>
    		public void On_Edited_callback(object o, EditedArgs args)
    		{
    			object quedObject = EditingQueue.Dequeue ();
    			NewCellRentererText ncrt = quedObject as NewCellRentererText;
    			if (null == ncrt)
    				return;
    
    			TreeIter iter;
    			TreePath path = new TreePath (args.Path);
    			if (!musicListStore.GetIter (out iter, path))
    				return;
    
    			XElement dummy = XElementIndexer [iter];  
    			if (dummy.Attribute (ncrt.XmlAttributeName) != null)
    				dummy.SetAttributeValue (ncrt.XmlAttributeName, args.NewText);
    			else
    				foreach (string attrKvp in args.NewText.Split(";".ToCharArray())) {
    					String[] attribute = attrKvp.Split (":".ToCharArray ());
    					if (attribute.Length > 1) // && dummy.Attribute (attribute [0].Trim ()) != null)
    						dummy.SetAttributeValue (attribute [0].Trim (), attribute [1].Trim ());
    				}
    			musicListStore.SetValue (iter, ncrt.ColumnIndex, args.NewText);
    			((NewCellRentererText)o).Text = args.NewText;
    		}
    
    		/// <summary>
    		/// Creates the new column.
    		/// set/reset the editable property
    		/// ans set name and Column Index in a new instance
    		/// of the new derived CellRendererText class 
    		/// </summary>
    		/// <returns>The new column.</returns>
    		/// <param name="index">Index.</param>
    		/// <param name="name">Name.</param>
    		/// <param name="editable">If set to <c>true</c> editable.</param>
    		private Gtk.TreeViewColumn CreateNewColumn(int index, string name, bool editable)
    		{
    			NewCellRentererText renderer = new NewCellRentererText ();
    			renderer.ColumnIndex =index ;
    			renderer.XmlAttributeName=name;
    			renderer.Editable = editable;
    			if (editable) {
    				renderer.Edited += On_Edited_callback;
    				renderer.EditingStarted += On_EditingStarted_callback;
    				renderer.EditingCanceled += On_EditingCanceled_callback;
    			}
    			Gtk.TreeViewColumn ret = new Gtk.TreeViewColumn (renderer.XmlAttributeName, renderer);
    			ret.AddAttribute (ret.CellRenderers [0], "text", index);
    			return ret;
    		}
    		/// <summary>
    		/// Initializes a new instance of the <see cref="TestWinForms.MainClass"/> class.
    		/// </summary>
    		public MainClass ()
    		{
    			// using Styles ( OPTIONAL EXPERIMENTAL BUT WORKING ) 
    			Gtk.Rc.Parse (System.IO.Path.Combine("Properties","ProcessOut.xml"));
    
    			// Normal stuff to create a tree view
    			Gtk.Window window = new Gtk.Window ("TreeView Example");
    			window.SetSizeRequest (800, 600);
    			window.Destroyed += On_WindowDestroyed_callback;
    
    			Gtk.TreeView tree = new Gtk.TreeView ();
    			window.Add (tree);
    
    			// one Part of the Solution to host column index
    			tree.AppendColumn (CreateNewColumn(0, "name", false));
    			tree.AppendColumn (CreateNewColumn(1, "id", false));
    			tree.AppendColumn (CreateNewColumn(2, "type", true));
    			tree.AppendColumn (CreateNewColumn(3, "class", true));
    			tree.AppendColumn (CreateNewColumn(4, "parameter", true));
    			tree.AppendColumn (CreateNewColumn(5, "others", true));
    			Type[] TypeList = Enumerable.Repeat (typeof(string), tree.Columns.Length).ToArray();
    				musicListStore = new Gtk.TreeStore (TypeList);
    
    			// some XML stuff to make something usefull
    			MainXMLElement = XElement.Load ("Properties/Process.xml",LoadOptions.PreserveWhitespace);
    			XElement y = MainXMLElement.Element ("processes");
    			XAttribute title = y.Attribute ("name");
    			TreeIter iter =  musicListStore.AppendValues(title == null ? y.Name.ToString() : title.Value);
    			XElementIndexer.Add (iter, y);
    
    			walkThroughXml (y, musicListStore, iter);
    
    			// using row filter  ( OPTIONAL EXPERIMENTAL BUT WORKING ) 
    			Gtk.TreeModelFilter filter = new Gtk.TreeModelFilter (musicListStore, null);
    			filter.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
    
    			tree.Model = filter;
    
    			// Now let us see
    			window.ShowAll ();
    		}
    		/// <summary>
    		/// Walks the through xml.
    		/// recursive TreView filling based on an XML Element
    		/// </summary>
    		/// <param name="xe">Xe.</param>
    		/// <param name="ts">Ts.</param>
    		/// <param name="ti">Ti.</param>
    		public void walkThroughXml(XElement xe, Gtk.TreeStore ts, Gtk.TreeIter ti )
    		{
    			if (!xe.HasElements)
    				return;
    			IEnumerable<XElement> elements = xe.Elements ();
    			foreach ( XElement element in elements )
    			{
    				// this part could be more generic, but it works for my requirements
    				String Xid = "";
    				String Xtype = "";
    				String Xclass = "";
    				String Xparameter = "";
    
    				System.Text.StringBuilder dataExpression = new System.Text.StringBuilder();
    				XAttribute title = element.Attribute ("name");
    				foreach (XAttribute data in element.Attributes()) {
    					switch (data.Name.ToString ()) {
    					case "name":
    						break;
    					case "id":
    						Xid = data.Value;
    						break;
    					case "type":
    						Xtype = data.Value;
    						break;
    					case "class":
    						Xclass = data.Value;
    						break;
    					case "parameter":
    						Xparameter = data.Value;
    						break;
    					default:
    						dataExpression.AppendFormat ("{0}: {1} ; ", data.Name.ToString (), data.Value);
    						break;
    					}
    				}
    				TreeIter iter = (TreeIter)ts.AppendValues (ti, title == null ? element.Name.ToString () : title.Value, Xid,Xtype,Xclass,Xparameter, dataExpression.ToString ());
    				walkThroughXml (element, ts, iter);
    				XElementIndexer.Add (iter,element);
    			}
    		}
    		/// <summary>
    		/// Filters the tree.		
    		///
    		/// for filtering , this was only experimental, but it works fine. 
    		/// So if it is needed ....
    		///
    		/// </summary>
    		/// <returns><c>true</c>, if tree was filtered, <c>false</c> otherwise.</returns>
    		/// <param name="model">Model.</param>
    		/// <param name="iter">Iter.</param>
    		private bool FilterTree (Gtk.TreeModel model, Gtk.TreeIter iter)
    		{
    			if (DynamicTreeFilterRegEx == null)
    				return true;
    			string searchName = model.GetValue (iter, DynamicTreeFilterColumn).ToString ();
    			return DynamicTreeFilterRegEx.IsMatch (searchName);
    		}
    
    	}
    }
    
    
