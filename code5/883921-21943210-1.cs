    if (imageToByteArray(Image.FromFile(openFileDialogPhoto.FileName)) == null)
    {
        repository.WorkflowsRepository.AddEmployee(txtboxName.Text, dateTimePickerBirthDate.Value, dateTimePickerHireDate.Value, gGender, txtboxMobile.Text, txtboxAddress.Text, txtboxEmail.Text,null);
    }
    else
    {
        repository.WorkflowsRepository.AddEmployee(txtboxName.Text, dateTimePickerBirthDate.Value, dateTimePickerHireDate.Value, gGender, txtboxMobile.Text, txtboxAddress.Text, txtboxEmail.Text, imageToByteArray(Image.FromFile(openFileDialogPhoto.FileName)));
    }
