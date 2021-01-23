    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
             ProjectIDs = new BindingList<AwesomeLong>();
             var source = new BindingSource( ProjectIDs, null );
             dataGridView1.DataSource = source;
             dataGridView1.Columns.Add( new DataGridViewTextBoxColumn() );
          }
    
          BindingList<AwesomeLong> ProjectIDs;
          private int i = 0;
    
          
          private void button1_Click( object sender, EventArgs e )
          {
             i++;
             ProjectIDs.Add(new AwesomeLong(i));
          }
    
       }
    
       public class AwesomeLong
       {
          public long LongProperty { get; set; }
    
          public AwesomeLong( long longProperty )
          {
             LongProperty = longProperty;
             NotifyPropertyChanged("AwesomeLong");
          }
    
          public event PropertyChangedEventHandler PropertyChanged;
    
          // This method is called by the Set accessor of each property. 
          // The CallerMemberName attribute that is applied to the optional propertyName 
          // parameter causes the property name of the caller to be substituted as an argument. 
          private void NotifyPropertyChanged( String propertyName = "" )
          {
             if ( PropertyChanged != null )
             {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
             }
          }
       }
    }
