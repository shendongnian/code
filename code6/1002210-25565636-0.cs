    public sealed class Restriction
    {
        public sealed class Asset
        {
            public int AssetId { get; set; }
            public int SegmentId { get; set; }
            public int SubAssetId { get; set; }
        }
        public string Portefeuille { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        [Required]
        public Asset AssetOne { get; set; }
        // Not required and, therefore, optional.
        public Asset AssetTwo { get; set; }
    }
