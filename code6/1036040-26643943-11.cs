        public void ProcessLogicBuffer()
        {
            foreach (var tag in LogicBuffer.GetConsumingEnumerable())
            {
                ProcessNewTagReceivedLogic(tag);
                Console.WriteLine("Process Buffer #Tag {0}. Buffer Count #{1}", tag.NewLoopId, LogicBuffer.Count);
            }
        }
