    %n[!format_specifier!]	Describes an insert. Each insert is an entry in the 
        Arguments array in the FormatMessage function. The value of n can be a number 
        between 1 and 99. The format specifier is optional. If no value is specified, 
        the default is !s!. For information about the format specifier, see wsprintf. 
        The format specifier can use * for either the precision or the width. When 
        specified, they consume inserts numbered n+1 and n+2.
    %0	Terminates a message text line without a trailing newline character. This can 
        be used to build a long line or terminate a prompt message without a trailing 
        newline character.
    %.	Generates a single period. This can be used to display a period at the 
        beginning of a line, which would otherwise terminate the message text.
    %!	Generates a single exclamation point. This can be used to specify an 
        exclamation point immediately after an insert.
    %%	Generates a single percent sign.
    %n	Generates a hard line break when it occurs at the end of a line. This can be 
        used with FormatMessage to ensure that the message fits a certain width.
    %b	Generates a space character. This can be used to ensure an appropriate number 
        of trailing spaces on a line.
    %r	Generates a hard carriage return without a trailing newline character.
