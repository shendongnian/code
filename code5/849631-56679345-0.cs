csharp
[Export]
public class Foo<T> where T : Bar { }
[Export]
public class FooUnconstrained<T> { }
[Export]
public class Bar { }
Closing an **unconstrained** generic type ***works*** regardless of whether `RegistrationBuilder` is passed:
csharp
using (var catalogue = new ApplicationCatalog(new RegistrationBuilder()))
using (var container = new CompositionContainer(catalogue))
{
    Console.WriteLine(container.GetExport<FooUnconstrained<Bar>>().Value);
}
Closing a **constrained** generic type only ***works*** **without `RegistrationBuilder`**:
csharp
using (var catalogue = new ApplicationCatalog())
using (var container = new CompositionContainer(catalogue))
{
    Console.WriteLine(container.GetExport<Foo<Bar>>().Value);
}
Closing a **constrained** generic type ***fails*** when **using `RegistrationBuilder`**:
csharp
using (var catalogue = new ApplicationCatalog(new RegistrationBuilder()))
using (var container = new CompositionContainer(catalogue))
{
    // Next line throws ImportCardinalityMismatchException:
    Console.WriteLine(container.GetExport<Foo<Bar>>().Value);
}
This seems like a bug with .net. I am experiencing this behavior on releaseKey=528040 (.net-4.8 preview).
I personally recommend against the conventional model anyway because it requires the compositor to know about all of the conventions. This means that you cannot bring together two different code bases which use different conventions without manually combining their convention logic. I.e., it introduces tight coupling that doesn’t exist with the attributed model.
