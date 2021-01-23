    public static class Extensions
    {
        public static int CountByText(this TreeNode view, string text)
        {
            int count = 0;
            //logic to iterate through nodes and do count
            foreach (TreeNode node in view.Nodes)
            {
                if (node.Text == text)
                {
                    count++;
                }
            }
            return count;
        }
    }
