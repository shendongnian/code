    // Pseudocode to serialize two objects into the same file
    // First serialize to memory    
    byte[] bytes1 = object1.Serialize();
    byte[] bytes2 = object2.Serialize();    
    // Write header:
    file.Write(2);              // Number of objects
    file.Write(bytes1.Length);  // Size of first object
    file.Write(bytes2.Length);  // Size of second object
    // Write data:
    file.Write(bytes1);
    file.Write(bytes2);
