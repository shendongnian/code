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
                // painting 1000 rects like this takes about 12msec
                // frameGraphics.FillRectangle(Brushes.Red, rect);
            }
            // painting all 1000 rects at once will take only 3msec
            frameGraphics.FillRectangles(Brushes.Red, Water.ToArray());
