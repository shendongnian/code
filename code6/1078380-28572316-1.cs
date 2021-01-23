    public partial class PackageStatusForm : Form
    {
        public PackageStatusForm(TaskHost taskHost, IServiceProvider serviceprovider)
        {
            this.TaskHost = taskHost;
            this.ServiceProvider = serviceprovider;
            
            InitializeComponent();
           
            if (this.TaskHost != null && this.TaskHost.Variables != null)
            {
                // Goes though each variable, to display the shortcut
                foreach (Variable var in taskHost.Variables)
                {
                    variableList.Items.Add(var.QualifiedName);
                }
                // Can set labels to variable name, text boxes to allow the expressions, etc
                foreach (LabelTextDisplay ppt in this.flowLayoutPanel1.Controls)
                {
                    this.TaskHost.SetExpression(ppt.PropertyName, ppt.ExpressionValue);
                }
            }
        }
    }
