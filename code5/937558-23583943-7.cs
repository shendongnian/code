            for (var x = 0; x < Water3.Count; x++)
            {
                Rectangle rect = Water3[x];
                rect.Y++;
                bool intersect = Water3.Where((t, i) => i != x).Any(check => check.IntersectsWith(rect));
                if (rect.Y >= 699 || intersect)
                    rect.Y--;
                Water[x] = rect;
                // painting 1000 rects like this takes about 12msec
                // frameGraphics.FillRectangle(Brushes.Red, rect);
            }
            // painting all 1000 rects at once will take only 3msec
            frameGraphics.FillRectangles(Brushes.Red, Water.ToArray());
