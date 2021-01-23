    var method = new DynamicMethod( "", typeof( object ), new Type[ 0 ] );
    var emiter = method.GetILGenerator();
    var expando = emiter.DeclareLocal( typeof( ExpandoObject ) );
    emiter.Emit( OpCodes.Newobj, typeof( ExpandoObject ).GetConstructors()[ 0 ] );
    emiter.Emit( OpCodes.Stloc, expando );
    
    var value = emiter.DeclareLocal( typeof( int ) );
    emiter.Emit( OpCodes.Ldc_I4_1 );
    emiter.Emit( OpCodes.Stloc, value );
    
    emiter.Emit( OpCodes.Ldloc, expando );
    emiter.Emit( OpCodes.Ldnull );
    emiter.Emit( OpCodes.Ldc_I4, -1 );
    emiter.Emit( OpCodes.Ldloc, value );
    if ( value.LocalType.IsValueType )
        emiter.Emit( OpCodes.Box, value.LocalType );
    else
    {
        emiter.Emit( OpCodes.Castclass, typeof( object ) );
    }
    emiter.Emit( OpCodes.Ldstr, "Test" );
    emiter.Emit( OpCodes.Ldc_I4_0 );
    emiter.Emit( OpCodes.Ldc_I4_1 );
    emiter.Emit( OpCodes.Call, typeof( ExpandoObject ).GetMethod( "TrySetValue", BindingFlags.Instance | BindingFlags.NonPublic ) );
    
    emiter.Emit( OpCodes.Ldloc, expando );
    emiter.Emit( OpCodes.Ret );
    var @delegate = (Func<dynamic>)method.CreateDelegate( typeof( Func<dynamic> ) );
    
    var result = @delegate().Test;
