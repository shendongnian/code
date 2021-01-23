        namespace MyProject
        {
            /// <summary>
            /// Defiine your connectionstring and connection
            /// </summary>
            /// 
           
            public partial class Form1 : Form
            {   string connString = "Server=10*****;Port=3306;Database=e***;Uid=e***;password=********************;";
                  public Form1()
            {                   
                 InitializeComponent();
                
                 MySqlConnection conn = new MySqlConnection(connString);
               
            }
    .........
    .
