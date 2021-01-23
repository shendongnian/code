        private void btPlayer_Click(object sender, EventArgs e)
        {
            foreach(Button btn in this.Controls.OfType<Button>())
            {
                if (!btn.Equals(btPlayer))
                {
                    if (btPlayer.Bounds.IntersectsWith(btn.Bounds))
                    {
                        Console.WriteLine("btPlayer intersects with " + btn.Name);
                    }
                }
            }
        }
