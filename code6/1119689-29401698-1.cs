    private int EvaluateEnergy()
        {
            var energy = 0;
            if(checkBox1.Checked)
            {
                //Assign to every check box a energy value e.g 10
                energy += 10;
            }
            if(checkBox2.Checked)
            {
                //e.g 20
                energy += 20;
            }
            ......
            return energy + 1600;
        }
