    Unbehandelte Ausnahme: System.TypeInitializationException: Der Typeninitialisierer für "ConsoleApplication1.Program" hat eine Ausnahme verursacht. 
    ---> System.ArgumentException: Ein Element mit dem gleichen Schlüssel wurde bereits hinzugefügt.
       bei System.ThrowHelper.ThrowArgumentException(ExceptionResource resource)
       bei System.Collections.Generic.Dictionary``2.Insert(TKey key, TValue value, Boolean add)
       bei System.Collections.Generic.Dictionary``2.Add(TKey key, TValue value)
       bei ConsoleApplication1.Program..cctor() in Program.cs:Zeile 19.
       --- Ende der internen Ausnahmestapelüberwachung ---
       bei ConsoleApplication1.Program.Main(String[] args)
