            SvnClient client = new SvnClient();
            SvnStatusArgs sa = new SvnStatusArgs();
            sa.Depth = SvnDepth.Infinity;
            sa.RetrieveAllEntries = true; //the new line
            Collection<SvnStatusEventArgs> statuses;
            client.GetStatus(path, sa, out statuses);
