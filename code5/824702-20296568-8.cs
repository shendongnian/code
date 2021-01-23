               switch (comboBox1.SelectedItem.ToString().Split(" ")[0])
                {
                    case "Runescape":
                        MessageBox.Show("You are playing RS");
                        break;
            
                    case "Maplestory":
                        MessageBox.Show("You are playing MS");
                        break;
            
                    default:
                        MessageBox.Show("You're playing League");
                        break;
                }
