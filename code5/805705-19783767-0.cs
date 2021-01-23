            TabVsShape shape = new TabVsShape();
            shape.RightToLeft = true;
            foreach (RadPageViewPage p in radPageView1.Pages)
            {
                p.Item.Shape = shape;
                p.Item.MinSize = new Size(65, 0); //if you need to increase the page item size
            }
