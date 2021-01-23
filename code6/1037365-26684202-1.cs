      public partial class ExampleForm : Form
      {
        public ExampleForm()
        {
          InitializeComponent();
          ArrayRankIssue.ExampleClass exampleClass2 = new ArrayRankIssue.ExampleClass();
          this.exampleControl1.Example = exampleClass2;
        }
      }
