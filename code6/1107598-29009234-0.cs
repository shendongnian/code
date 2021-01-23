	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	namespace Fortrus.Intranet.WebControls
	{
		/// <summary>
		/// Produces a GridView with 'Edit', 'Cancel' and 'Insert' buttons
		/// </summary>
		public class CttGridView : GridView
		{
			public CttGridView()
			{
				ShowHeaderWhenEmpty = true;
				ShowFooter = true;
				RowDataBound += CttGridView_RowDataBound;
			}
			void CttGridView_RowDataBound(object sender, GridViewRowEventArgs e)
			{
				e.Row.Cells[e.Row.Cells.Count - 1].Width = new Unit(50, UnitType.Pixel);
			}
			/// <summary>
			/// This class is used to fill the different templates in the gridview dynamically
			/// </summary>
			public class StandardGridViewTemplateGenerator : ITemplate
			{
				private ListItemType Type;
				private DataControlFieldCollection Columns;
				/// <summary>
				/// In this variable the initialy defined columns are saved
				/// This is needed because we also add a column to the gridview
				/// </summary>
				private DataControlFieldCollection InitialColumns;
				public StandardGridViewTemplateGenerator(ListItemType type, DataControlFieldCollection columns = null)
				{
					Type = type;
					Columns = columns;
					if (columns != null)
					{
						InitialColumns = new DataControlFieldCollection();
						// Save the columns initialy defined for the gridview
						foreach (DataControlField column in columns)
						{
							InitialColumns.Add(column);
						}
					}
				}
				/// <summary>
				/// Method of the ITemplate interface is called when a specific template is needed
				/// </summary>
				void ITemplate.InstantiateIn(Control container)
				{
					switch (Type)
					{
						// The tamplate for editing is needed
						case ListItemType.EditItem:
							CreateEditButtons(container);
							break;
						// A display template is needed
						case ListItemType.Item:
							CreateItemButtons(container);
							break;
						// A footer template is needed
						case ListItemType.Footer:
							CreateColumnControls(container);
							break;
						case ListItemType.SelectedItem:
						case ListItemType.AlternatingItem:
						case ListItemType.Header:
						case ListItemType.Pager:
						case ListItemType.Separator:
						default:
							throw new NotImplementedException();
					}
				}
				/// <summary>
				/// Generate the footer controls from the initial columns
				/// </summary>
				private void CreateColumnControls(Control container)
				{
					if (InitialColumns != null)
					{
						TableRow row = new TableRow();
						foreach (TemplateField column in InitialColumns)
						{
							TableCell cell = new TableCell();
							row.Controls.Add(cell);
							column.EditItemTemplate.InstantiateIn(cell);
						}
						CreateInsertButtons(row);
						container.Controls.Add(row);
					}
					else
					{
						CreateInsertButtons(container);
					}
				}
				/// <summary>
				/// Adds buttons for the empty (footer) template
				/// </summary>
				private void CreateInsertButtons(Control container)
				{
					Control control = container;
					if (container is TableRow)
					{
						control = new TableCell();
						container.Controls.Add(control);
					}
					AddButton(control,
						id: "AddNewButton",
						cssClass: "CttGridViewSaveButton",
						commandName: "Insert",
						toolTip: "Toevoegen");
					AddButton(control,
						id: "CancelNewButton",
						cssClass: "CttGridViewCancelButton",
						commandName: "Cancel",
						toolTip: "Ongedaan maken");
				}
				/// <summary>
				/// Adds buttons for the Edit template
				/// </summary>
				private void CreateEditButtons(Control container)
				{
					AddButton(container,
						id: "SaveButton",
						cssClass: "CttGridViewSaveButton",
						commandName: "Update",
						toolTip: "Opslaan");
					AddButton(container,
						id: "CancelButton",
						cssClass: "CttGridViewCancelButton",
						commandName: "Cancel",
						toolTip: "Ongedaan maken");
				}
				/// <summary>
				/// Adds buttons for the (display) item template
				/// </summary>
				private void CreateItemButtons(Control container)
				{
					AddButton(container,
						id: "EditButton",
						cssClass: "CttGridViewEditButton",
						commandName: "Edit",
						toolTip: "Bewerken");
					AddButton(container,
						id: "DeleteButton",
						cssClass: "CttGridViewDeleteButton",
						commandName: "Delete",
						toolTip: "Verwijderen",
						confirmation: "return confirm('Weet u zeker dat u deze rij wilt verwijderen?');");
				}
				/// <summary>
				/// Adds a button to the container
				/// </summary>
				private static void AddButton(Control container, string id, string cssClass, string commandName, string toolTip, string confirmation = null)
				{
					ImageButton button = new ImageButton();
					button.ID = id;
					button.CssClass = cssClass;
					button.CommandName = commandName;
					button.ToolTip = toolTip;
					button.OnClientClick = confirmation;
					// Added blank image to prevent the default gray placeholder border
					// Image should be set using the background-image from CSS
					button.ImageUrl = "data:image/png;base64,R0lGODlhFAAUAIAAAP///wAAACH5BAEAAAAALAAAAAAUABQAAAIRhI+py+0Po5y02ouz3rz7rxUAOw==";
					container.Controls.Add(button);
				}
			}
			/// <summary>
			/// Create the child controls
			/// </summary>
			protected override void CreateChildControls()
			{
				ShowFooter = true;
				InitializeTemplate();
				base.CreateChildControls();
			}
			/// <summary>
			/// Initialize the templates
			/// </summary>
			private void InitializeTemplate()
			{
				TemplateField template = new TemplateField();
				template.ItemTemplate = new StandardGridViewTemplateGenerator(ListItemType.Item);
				template.EditItemTemplate = new StandardGridViewTemplateGenerator(ListItemType.EditItem);
				template.FooterTemplate = new StandardGridViewTemplateGenerator(ListItemType.Footer);
				EmptyDataTemplate = new StandardGridViewTemplateGenerator(ListItemType.Footer, columns: Columns);
				Columns.Add(template);
			}
		}
	}
