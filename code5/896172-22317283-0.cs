       private void Handle_Drag(object sender,System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            TextBox Text = sender as TextBox;
            var parent = Text.Parent as Grid;
            if (parent  != null)
            {
                parent.Children.Remove(Text);
                myCanvas.Children.Add(Text);
            }
            Text.Text = "I'm moved";
            double currentX = Canvas.GetLeft(Text);
            double currentY = Canvas.GetTop(Text);
            MessageBox.Show(currentX.ToString());
            MessageBox.Show(currentY.ToString());
            Canvas.SetLeft(Text, currentX + e.DeltaManipulation.Translation.X);
            Canvas.SetTop(Text, currentY + e.DeltaManipulation.Translation.Y); 
        }
