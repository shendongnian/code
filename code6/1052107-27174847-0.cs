    // Writes the text representation of an object to the text stream. If the
    // given object is null, nothing is written to the text stream.
    // Otherwise, the object's ToString method is called to produce the
    // string representation, and the resulting string is then written to the
    // output stream.
    //
    public virtual void Write(Object value) {
        if (value != null) {
            IFormattable f = value as IFormattable;
            if (f != null)
                Write(f.ToString(null, FormatProvider));
            else
                Write(value.ToString());
        }
    }
