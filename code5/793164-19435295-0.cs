    Mono.Unix.UnixSymbolicLinkInfo i = new Mono.Unix.UnixSymbolicLinkInfo( path );
    switch( i.FileType )
    {
       case FileTypes.SymbolicLink:
       case FileTypes.Fifo:
       case FileTypes.Socket:
       case FileTypes.BlockDevice:
       case FileTypes.CharacterDevice:
       case FileTypes.Directory:
       case FileTypes.RegularFile:
    }
