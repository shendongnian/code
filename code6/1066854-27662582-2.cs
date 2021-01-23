	private static Dictionary<Type, Func<Vector3, Block>> _activators = new Dictionary<Type, Func<Vector3, Block>>();
    public static Block CreateBlock(Type blockType, Vector3 position)
    {
        Func<Vector3, Block> factory;
       
        if (!_activators.TryGetValue(blockType, out factory))
        {
            if (!typeof(Block).IsAssignableFrom(blockType))
                throw new ArgumentException();
            var posParam = Expression.Parameter(typeof(Vector3));
            factory = Expression.Lambda<Func<Vector3, Block>>(
                Expression.New(
                    blockType.GetConstructor(new[] { typeof(Vector3) }),
                    new[] { posParam }
                ),
                posParam
            ).Compile();
        }
        return factory(position);
    }
