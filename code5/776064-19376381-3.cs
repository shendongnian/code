            //---------------------------------------------------------------------------
        GraphPane lastpan;
        public void UCclicked(PointF mousePt)
        {
            GraphPane pan= masterPane.FindPane(mousePt);
            if (pan != null)
            {
                if (pan == lastpan)
                    ShowAllGraphs();
                else
                    ShowOneGraph(plist.IndexOf(pan));     
 
                lastpan = pan;
            }
        }
