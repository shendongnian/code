    public interface IBinarySerialize
    {
      /// <summary>Reads an object's data from a <see cref="Stream"/></summary>
      void Read( Stream stream );
      /// <summary>Writes an objects serializable content to a <see cref="Stream"/></summary>
      void Write( Stream stream );
    }
