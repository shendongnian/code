    public static class Prompt
    {
        public static string ShowDialog(int columnnumber, string columnname)
        {
            Form prompt = new Form();
            // other code
            return prompt.DialogResult == DialogResult.OK ? comboBox.Text : null;
        }
    }
