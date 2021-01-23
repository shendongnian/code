    context.OfficeAssignments.Add(new OfficeAssignment(instructorBeingUpdated, instructorOfficeTextBox.Text, null));
        
    context.officeAssignments.remove(officeAssignment);
    
    var allCourses = context.Courses().ToList();
