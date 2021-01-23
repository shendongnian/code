       MasterPane masterPane;
        PaneList plist = new PaneList();
        private void InitGraphs()
        {
            //Zedgraph control 
            var zgc = Apprefs.Zedgraph;
            //MasterPan
            masterPane = zgc.CreateMasterPan(Title, System.Drawing.Color.White);
            // CreateMultiGraph is my own API to create Graph
            zgc.CreateMultiGraph("Graph1", 1, "G1xtitle", "G1ytitle", false);
            zgc.CreateMultiGraph("Graph2", 1, "G2xtitle", "G2ytitle", false);
            zgc.CreateMultiGraph("Graph3", 1, "G3xtitle", "G3ytitle", false);
            // save the Pans
                 foreach (GraphPane graph in masterPane.PaneList)
                    plist.Add(graph);            
        }
        //---------------------------------------------------------------------------
        public void Englare(RichButton button)
        {
            var graph = Apprefs.Zedgraph2.graph;
            if (button.Name == "Show1")
            {
                ShowOneGraph(0);
            }
            else if (button.Name == "Show2")
            {
                ShowOneGraph(1);
            }
            else if (button.Name == "ShowAll")
            {
                ShowAllGraphs();
            }
        }
        //---------------------------------------------------------------------------
        private void ShowOneGraph(int Graphindex)
        {
            if (masterPane == null) return;
            var graph = Apprefs.Zedgraph.graph;
            if (Graphindex >= 0 && Graphindex < plist.Count)
            {
                masterPane.PaneList.Clear();
                masterPane.PaneList.Add(plist[Graphindex]);
                Layout();
            }
        }
        //---------------------------------------------------------------------------
        private void ShowAllGraphs()
        {
            if (masterPane == null) return;
            var graph = Apprefs.Zedgraph.graph;
    
                masterPane.PaneList.Clear();
                foreach (GraphPane gr in plist)
                    masterPane.PaneList.Add(gr);
                Layout();           
        }
        //---------------------------------------------------------------------------
        private void Layout()
        {
            var graph = Apprefs.Zedgraph2.graph;
            using (Graphics g = graph.CreateGraphics())
            {
                masterPane.SetLayout(g, PaneLayout.SingleColumn);
                graph.AxisChange();
                graph.Refresh();
            }
        }
        //---------------------------------------------------------------------------
