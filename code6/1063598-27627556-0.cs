    namespace CorsicanaNetWeightProgram
    {
        public partial class PieceCodepc : Form
        {
            public PieceCodepc()
            {
                InitializeComponent();
            }
    
            private void PieceCodepc_Load(object sender, EventArgs e)
            {
                // TODO: This line of code loads data into the 'dataSet1.DataTable1' table. You can move, or remove it, as needed.
                this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
             
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                
                // TODO: This line of code loads data into the 'empty.Piece_Dimension_Master_Data' table. You can move, or remove it, as needed.
                this.Piece_Dimension_Master_DataTableAdapter.Fill(this.empty.Piece_Dimension_Master_Data, comboBox1.SelectedValue.ToString());
    
                this.reportViewer1.RefreshReport();
    
             
            }
        }
    }
