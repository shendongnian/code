        public Sequencer()
        {
            SeqNode = Node.LoadNode(Context);
            SequenceNumber = Convert.ToInt16(SeqNode["LastSequenceNo"]);
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                while (Run)
                {
                    Save();
                    Thread.Sleep(5000);
                }
            });
