set {
var description = string.Empty;
var substrings = "".Split( '.' );
for ( int i = 0; i < substrings.Length; i++ )
{
   description += substrings[i];
   if ( i%5 == 0 )
   {
       description += Environment.NewLine;
   }
}
}
this.SetProperty(ref this._description, description);
