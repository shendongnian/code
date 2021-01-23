    private void peopleGridView_DoubleClick(object sender, EventArgs e)
    {
        if (peopleGridView.CurrentRow == null)
            return;
        Person person = (Person)peopleGridView.CurrentRow.DataBoundItem;
        using (var detailsForm = new PersonDetailsForm(person))
        {
            detailsForm.ShowDialog();
        }
    }
