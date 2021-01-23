    private GridItem Root
        {
            get
            {
                GridItem aRoot = myPropertyGrid.SelectedGridItem;
                do
                {
                    aRoot = aRoot.Parent ?? aRoot;
                } while (aRoot.Parent != null);
                return aRoot;
            }
        }
