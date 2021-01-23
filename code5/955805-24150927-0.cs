    public class Form
    {
        public Button Mele { get; set; }
        public Label Character1 { get; set; }
        public Form()
        {
             Character1 = new TextBox();
             Mele = new Button();
             Mele.Click += OnButtonClicked;
        }
     private void OnButtonClicked(object sender, System.EventArgs e)
    {
          // Since Character1 is declared at class level, you may
          // access it now inside the method
         Character1.Text = "Mele has been clicked!";
    }
