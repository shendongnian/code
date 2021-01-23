    private void getMax()
    {
       int max=0;
       for (int i = 0; i < lstPoints.Items.Count; i++)
            {
                 if(max<(int)lstPoints.Items[i])
                     {
                         max=(int)lstPoints.Items[i];
                     }
            }
            
            lblResult.Text = max.ToString(); 
            }
      
    }
    
    private void getMin()
    {
       int min=(int)lstPoints.Items[0];
       for (int i = 1; i < lstPoints.Items.Count; i++)
            {
                 if(min>(int)lstPoints.Items[i])
                     {
                         min=(int)lstPoints.Items[i];
                     }
            }
            
            lblResult.Text = min.ToString(); 
            }
      
    }
