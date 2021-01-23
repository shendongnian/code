    .assembly test {}
    .assembly extern mscorlib {}
    
    .class public Delta
    {
      .method public static void 'Δ'()
      {
          .entrypoint
          ldstr "Hello, delta!"
          call void [mscorlib]System.Console::WriteLine(string)
          ret
      }
    }
