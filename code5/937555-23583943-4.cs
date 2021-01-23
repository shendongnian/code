            for (var x = 0; x < Water3.Count; x++)
            {
                bool intersect = false;
                Rectangle rect = Water3[x];
                rect.Y++;
                for (var i = 0; i < Water3.Count; i++)
                {
                    if (i == x)
                        continue;
                    Rectangle check = Water3[i];
                    if (check.IntersectsWith(rect))
                    {
                        intersect = true;
                        break;
                    }
                }
                if (rect.Y >= 699 || intersect)
                    rect.Y--;
                Water[x] = rect;
                frameGraphics.FillRectangle(Brushes.Red, rect);
            }
