    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace FormToFormExample
    {
        public partial class Form2 : Form
        {
            EmployeeModel _model;
    
            #region Constructors
            public Form2()
            {
                InitializeComponent();
                BindComponents();
            }
    
            public Form2(EmployeeModel model)
                : this()
            {
                this._model = model;
            } 
            #endregion
    
            #region Methods
            private void BindComponents()
            {
                this.Load += Form2_Load;
            }
    
            private void Initialize()
            {
                this.label1.Text = this._model.EmployeeID.ToString();
                this.label2.Text = this._model.Name;
            } 
            #endregion
    
            #region Events
            void Form2_Load(object sender, EventArgs e)
            {
                Initialize();
            }  
            #endregion
        }
    }
