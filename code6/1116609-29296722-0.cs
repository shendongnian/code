        private void btnShowBadHabits_Click(object sender, EventArgs e)
        {
            Cat cat = new Cat("", null, "", "Good", (Gender)cbGender.SelectedItem);
            Animal animal = cat;
            if (animal is Cat)
            {
                lbShowCatHabits.Items.Add(cat.BadHabits);
            }
            else
            {
                MessageBox.Show("No cats found");
            }
