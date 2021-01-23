    switch (userType)
    {
        case "Doctor":
            string qualification = Microsoft.VisualBasic.Interaction.InputBox("What is the highest qualification this person has", "Qualification", "", -1, -1);
            DateTime dateStarted = RequestStartDate();
            string field = Microsoft.VisualBasic.Interaction.InputBox("In which field does this person practice", "Field", "", -1, -1);
            CreateDoctor(qualification, dateStarted, field);
            break;
