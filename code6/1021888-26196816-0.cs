    private void dgEmployee_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Employee selectedEmp = dgEmployee.Items[prevRowIndex] as Employee;
                if (selectedEmp == null)
                    return;
                DragDropEffects dragdropeffects = DragDropEffects.Move;
                if (DragDrop.DoDragDrop(dgEmployee, selectedEmp, dragdropeffects)
                                != DragDropEffects.None)
                {
                    //Now This Item will be dropped at new location and so the new Selected Item
                    dgEmployee.SelectedItem = selectedEmp;
                }
            }
        }
