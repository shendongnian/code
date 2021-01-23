    private void openForm2()
    {
        var f2 = new Form2(); //create new form2
        var formResult = f2.ShowDialog(); //open as Dialog and check result after close event
        if (formResult == DialogResult.OK) //check form2 dialog result
        {
            //form2 gave OK, I can update my DGV and display msg
            MessageBox.Show("DGV will be updated", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //update my DGV
            UpdateDGV();
        }
        else
        {
            //form2 passed Cancel or something else, not good
            MessageBox.Show("Form2 Closed but nothing happened.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }   
