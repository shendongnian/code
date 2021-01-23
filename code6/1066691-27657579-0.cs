    [Serializable]
    [XmlType(TypeName="MyTypeName")]
    public struct KeyValuePair<T1, T2>
    {
      public T1 Key { get; set; }
      public T2 Value { get; set; }
    }
