    List<int> usedN = new List<int>();
    int[] n = new int[5] {1, 2, 3, 4, 5};
    Random rnd = new Random();
    
    private void button1_click(object sender, EventArgs e)
    {        
        int iRnd = rnd.Next(n[0], n[n.Length-1]);
        while(usedN.Contains(iRnd) != false)
        {
            //this can be infinite loop if all the numbers are used from the array.
            //So used items are got equal to array items then cursor shoulg get exit.
            if (usedN.Count == n.Length) 
                return;
            iRnd = rnd.Next(n[0], n[n.Length-1]);
            
        }
        usedN.Add(iRnd);
        MessageBox.Show("Number " + iRnd.ToString());
    }
