    for (int i = 0; i <= userCount; i++)
                        {
                        chk[i] = new CheckBox();
    
                        chk[i].Name = parts[i];
    
                        chk[i].Text = parts[i];
    
                        chk[i].TabIndex = i;
    
                        chk[i].AutoCheck = true;
    
                        chk[i].Bounds = new Rectangle(15, 30 + padding + height, 150, 22);
    
                        targetForm.Controls.Add(chk[i]);
    
                        height += 22;
    
                        }
