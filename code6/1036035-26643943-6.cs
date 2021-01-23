        public void ProcessLogicBuffer()
        {
            while (true)
            {   
                // Dequeue the list
                IRampActiveTag tag;
                LogicBuffer.TryDequeue(out tag);
                if (tag != null)
                {
                    ProcessNewTagReceivedLogic(tag);
                    Console.WriteLine("Process Buffer #Tag {0}. Buffer Count #{1}", tag.NewLoopId, LogicBuffer.Count);
                }
            }
        }
