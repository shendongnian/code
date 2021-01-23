    private void butEnroleStudent_Click(object sender, RoutedEventArgs e)
    {
        if (lbCourses.SelectedIndex >= 0 && cbStudents.SelectedIndex >= 0)
        {
            // Both a student and course are selected
            Course selectedCourse = (Course)lbCourses.SelectedItem;
            Student studentToAdd = (Student)cbStudents.SelectedItem;
            if (!selectedCourse.EnrolledStudents.Contains(studentToAdd))
            {
               // Course does not already contain student, add them
               selectedCourse.EnrolledStudents.Add(studentToAdd);
               lbEnroledStudents.Items.Refresh();
            }
        }
    }
