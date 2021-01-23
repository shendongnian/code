    Dictionary<long, IList<Cell>> ByBlock =
        mCache.ListBlocks.SelectMany(e => e.Value)
              .Where(e => listBlocks.Contains(e.Key)
                          && e.Key != null)  // filter out `null` values
              .Select(Block =>
                        new KeyValuePair<long, IList<CellToSubCatchment>>(
                            Block.Key,
                            DataMgr.GetMapping("CASH", Block,
                                               GetKey(IdKeys, Block),
                                               mType)))
              .ToDictionary(e => e.Key, e => e.Value);
