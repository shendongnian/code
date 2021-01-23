    int amount, interest;
    using (Form1 form = new Form1()) 
    {
        form.ShowDialog();
        amount = form.Amount;     // these, of course, have to be public
        interest = form.Interest; // make the fields private and expose them via properties
        [...]
    }
    using (Form2 form = new Form2(amount, interest))
    {
        form.ShowDialog();
    }
