    Dictionary<long, IList<Cell>> ByBlock = 
           mCache.ListBlocks
             .SelectMany(e => e.Value)
             .Where(e => listBlocks.Contains(e.Key))
             .ToDictionary(
                  block => block.Key, 
                  block => DataMgr.GetMapping("CASH",block,GetKey(IdKeys, block), mType))
             );
