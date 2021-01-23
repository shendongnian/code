    using System.Text;
    
    StringBuilder compartments = new StringBuilder();
    for (int i = 0; i < compartmentno.Length; )
                    {
                        if (compartmentno[i] == 0)
                        {
                            compartments.Append(++i.ToString() + ", ");
    
                        }
                    }
    
    MessageBox.Show("Available compartments are" + compartments.ToString());
