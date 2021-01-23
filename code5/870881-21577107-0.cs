        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBox1.SelectedIndex != -1) {
                string path = String.Concat("/students/student[@id=", listBox1.SelectedItem, "]/data/subject");
                FillListbox2(xm, path);
            }
        }
