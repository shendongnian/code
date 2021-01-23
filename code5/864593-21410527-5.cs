    public partial class BuildEditor : Form
    {
        public BuildEditor()
        {
            InitializeComponent();
            Label maxSkill = new Label();
            maxSkill.Name = "MaxSkil"; // need the ID to find it later (makes it easier)
            maxSkill.Location = new Point(1, 1);
            this.Controls.Add(maxSkill);
        }
        // This is just for testing; assumes you dragged a button from toolbox onto your
        // BuildEditor form in the Form Designer
        private void button1_Click(object sender, EventArgs e)
        {
            var changeTextForMaxSkill = new ChangeTextForMaxSkill();
            changeTextForMaxSkill.ChangeText(this, "MaxSkil");
        }
    }
    
    public class ChangeTextForMaxSkill
    {
        public void ChangeText(Form formInstance, string labelName)
        {
            // Get reference to the label
            var label = formInstance.Controls.Find(labelName, true).FirstOrDefault();
            if (null != label && label is Label)
            {             
                (label as Label) .Text = "test";
            }
        }
    }
