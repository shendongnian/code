    private void ChangeMajor_Button_Click(object sender, RoutedEventArgs e)
    {
        var query = Roster_Students.Where(s => s.Tno == Tno_TextBox.Text);
        foreach (var student in query) {
            student.Major = ChangeMajor_TextBox.Text;
            App.DBConnection.Update(student);
        }
    }
