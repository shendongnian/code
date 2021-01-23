	//
	// Summary:
	//     Return an instance (possibly shared or independent) of the given object name.
	//
	// Parameters:
	//   name:
	//     The name of the object to return.
	//
	// Type parameters:
	//   T:
	//     The type of the object to return.
	//
	// Returns:
	//     The instance of the object.
	//
	// Exceptions:
	//   Spring.Objects.Factory.NoSuchObjectDefinitionException:
	//     If there's no such object definition.
	//
	//   Spring.Objects.Factory.ObjectNotOfRequiredTypeException:
	//     If the object is not of the required type.
	//
	//   Spring.Objects.ObjectsException:
	//     If the object could not be created.
	//
	// Remarks:
	//      This method allows an object factory to be used as a replacement for the
	//     Singleton or Prototype design pattern.
	//     Note that callers should retain references to returned objects. There is
	//     no guarantee that this method will be implemented to be efficient. For example,
	//     it may be synchronized, or may need to run an RDBMS query.
	//     Will ask the parent factory if the object cannot be found in this factory
	//     instance.
	T GetObject<T>(string name);
