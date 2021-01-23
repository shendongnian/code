        static unsafe void RecycleString(string s, char[] newcontents)
        {
            // First, fix the string so the GC doesn't move it around on us, and get a pointer to the character data.
            fixed (char* ps = s)
            {
                // We need an integer pointer as well, to check capacity and update length.
                int* psi = (int*)ps;
                int capacity = psi[-2];
                // Don't overrun the buffer!
                System.Diagnostics.Debug.Assert(capacity > newcontents.Length);
                if (capacity > newcontents.Length)
                {
                    for (int i = 0; i < newcontents.Length; ++i)
                    {
                        ps[i] = newcontents[i];
                    }
                    // Add null terminator and update length accordingly.
                    ps[newcontents.Length] = '\0';
                    psi[-1] = newcontents.Length;
                }
            }
        }
