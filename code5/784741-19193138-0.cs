    [MetadataType("GameMetadata")]
    public partial class Game
    {
        public class GameMetadata
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int GameNumber; 
        }
    }
