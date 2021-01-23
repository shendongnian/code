    namespace com.myCompany.myApp
    {
        public partial class frm_Configuration : Form
        {
            public frm_Configuration(GeneratePDF generatePdf)
            {
                InitializeComponent();
                GeneratePDFBindingSource.DataSource = generatePdf;
                GeneratePDFBindingSource.EndEdit();
            }
        }
    }
