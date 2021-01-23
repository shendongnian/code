using System;
public class C {
    public void M() {
        var x = 7;
        switch(x) // START SWITCH
        {
            case 1:
                Console.WriteLine("Hello");
                break;
            case 2:
                Console.WriteLine("World");
                break;
            default:
                Console.WriteLine("Uh...");
                break;
        }
        // END SWITCH
        // START GOTO
        if (x == 1)
        {
        	goto Hello;
        }
        else if (x == 2)
        {
            goto World;
        }
        Console.WriteLine("Uh...");
        goto End;
    Hello:
        Console.WriteLine("Hello");
        goto End;
    World:
        Console.WriteLine("World");
    End:
        // END GOTO
        Console.WriteLine("Done");
    }
}
Compiling this with C# in release mode (using sharplab.io default 2.9.0) yields the following IL (i.e. bytecode for you Java folk):
.class private auto ansi '<Module>'
{
} // end of class <Module>
.class public auto ansi beforefieldinit C
    extends [mscorlib]System.Object
{
    // Methods
    .method public hidebysig 
        instance void M () cil managed 
    {
        // Method begins at RVA 0x2050
        // Code size 99 (0x63)
        .maxstack 2
        .locals init (
            [0] int32
        )
        IL_0000: ldc.i4.7
        IL_0001: stloc.0
        // START SWITCH
        IL_0002: ldloc.0
        IL_0003: ldc.i4.1
        IL_0004: beq.s IL_000c
        IL_0006: ldloc.0
        IL_0007: ldc.i4.2
        IL_0008: beq.s IL_0018
        IL_000a: br.s IL_0024
        IL_000c: ldstr "Hello"
        IL_0011: call void [mscorlib]System.Console::WriteLine(string)
        IL_0016: br.s IL_002e
        IL_0018: ldstr "World"
        IL_001d: call void [mscorlib]System.Console::WriteLine(string)
        IL_0022: br.s IL_002e
        IL_0024: ldstr "Uh..."
        IL_0029: call void [mscorlib]System.Console::WriteLine(string)
        // END SWITCH
        // START GOTO
        IL_002e: ldloc.0
        IL_002f: ldc.i4.1
        IL_0030: beq.s IL_0042
        IL_0032: ldloc.0
        IL_0033: ldc.i4.2
        IL_0034: beq.s IL_004e
        IL_0036: ldstr "Uh..."
        IL_003b: call void [mscorlib]System.Console::WriteLine(string)
        IL_0040: br.s IL_0058
        IL_0042: ldstr "Hello"
        IL_0047: call void [mscorlib]System.Console::WriteLine(string)
        IL_004c: br.s IL_0058
        IL_004e: ldstr "World"
        IL_0053: call void [mscorlib]System.Console::WriteLine(string)
        // END GOTO
        IL_0058: ldstr "Done"
        IL_005d: call void [mscorlib]System.Console::WriteLine(string)
        IL_0062: ret
    } // end of method C::M
    .method public hidebysig specialname rtspecialname 
        instance void .ctor () cil managed 
    {
        // Method begins at RVA 0x20bf
        // Code size 7 (0x7)
        .maxstack 8
        IL_0000: ldarg.0
        IL_0001: call instance void [mscorlib]System.Object::.ctor()
        IL_0006: ret
    } // end of method C::.ctor
} // end of class C
The switch form has 3 `beq` and 1 `br.s` and the goto form has 2 `beq` and 2 `br.s`, other than that they are identical.  The cost of `br.s` is presumably less than or equal to the cost of `beq` so the cost of the goto approach is not greater than the cost of the switch approach.
Finally, using goto is a bad idea.  If you want to argue about that fact please do so on a different question like this one: https://stackoverflow.com/questions/3517726/what-is-wrong-with-using-goto
