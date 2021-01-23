    public partial class BuildEditor : Form
    {
        public BuildEditor()
        {
            InitializeComponent();
            // Here is it only test. Because i have defined this label in buildEditor.designer.cs for form.
            Label maxSkill = new Label();
            maxSkill.Id = "MaxSkil"; // need the ID to find it later (makes it easier)
            maxSkill.Location = new Point(location.X, location.Y)
            this.Controls.Add(maxSkill);
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
