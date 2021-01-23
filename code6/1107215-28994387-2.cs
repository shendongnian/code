    .method private hidebysig specialname rtspecialname static 
        void .cctor () cil managed 
    {
        // Method begins at RVA 0x205f
        // Code size 11 (0xb)
        .maxstack 8
        IL_0000: call class [mscorlib]System.Collections.Generic.Dictionary`2<string, int32> MyClass::CreateDictionary()
        IL_0005: stsfld class [mscorlib]System.Collections.Generic.Dictionary`2<string, int32> MyClass::mydict
        IL_000a: ret
    } // end of method MyClass::.cctor
